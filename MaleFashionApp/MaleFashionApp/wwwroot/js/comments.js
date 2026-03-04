    (() => {

    window.addEventListener('load', () => {

        let $commBlock = $('.card-body');
        let postId = $('.one-post-id').text();
        let message = { };
        let currentParentId = null;
        
        let getOneComment = (oneComm) => {
            
            let childComm = getCommentsChilds(oneComm);

            let comm = `
                    <div class="d-flex mb-4">
                        <img src="${oneComm.Avatar}" 
                             alt="avatar" 
                             class="class="rounded-circle shadow-sm me-4""
                             width="45" height="45" />
                        <p class="one-comment-id">${oneComm.Id}</p>     
                        
                    
                        <div class="flex-grow-1">
                    
                            <div class="d-flex justify-content-between align-items-center">
                                <div>
                                    <span class="fw-semibold">${oneComm.Login}</span>
                                    <small class="text-muted ms-2">
                                        ${new Date(oneComm.DateOfPublished).toLocaleDateString()}
                                    </small>
                                </div>
                    
                                <a href="#!" class="reply-button">
                                    Reply
                                </a>
                            </div>
                    
                            <p class="mt-2 mb-2 text-secondary small">
                                ${oneComm.Message}
                            </p>
                    
                            <div class="ms-5 border-start ps-4 mt-3">
                                ${childComm}
                            </div>
                    
                        </div>
                    </div>`;
            
            return comm;
        }
    
        let getCommentsChilds = (oneComm) => {
            if (!oneComm.Childs || oneComm.Childs.length === 0)
                return '';

            return oneComm.Childs.map(childComm =>
                `<div class="d-flex mb-4">
                    <img src="${childComm.Avatar}" alt="avatar" class="rounded-circle shadow-sm me-4" width="40" height="40" />
                    <p class="one-comment-id">${childComm.Id}</p>     
                    <div class="flex-grow-1">
                        <div class="d-flex justify-content-between align-items-center">
                            <div>
                                <p class="mb-0 fw-semibold">${childComm.Login} <small class="text-muted ms-2">- ${childComm.DateOfPublished}</small></p>
                            </div>
                            <a href="#!" class="reply-button">
                                Reply
                            </a>
                        </div>
                        <p class="small text-secondary mb-0">
                            ${childComm.Message}
                        </p>
                        
                        <div class="ms-5 border-start ps-4 mt-3">
                            ${getCommentsChilds(childComm)}
                        </div>
                    </div>
                </div>`).join('');

            return childComm;
        }
        
        
        
        let renderComments = (comments, $parent) => {
            for (var i = 0; i < comments.length; i++) {
                $parent.append(getOneComment(comments[i]));
            }
            $('.reply-button').on('click', (e) => {
                let parentId = $(e.target).closest('.d-flex.mb-4')
                    .children('.one-comment-id')
                    .first()
                    .text()
                    .trim();
                currentParentId = parentId;
                console.log("Replying to:", currentParentId);
            })
            
        }

        let validateForm = (login, email, messageText) => {
            let errors = [];

            if (!login || login.trim().length < 3)
                errors.push("Login must be at least 3 characters.");

            let emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            if (!email || !emailRegex.test(email))
                errors.push("Invalid email address.");

            if (!messageText || messageText.trim().length < 3)
                errors.push("Message must be at least 3 characters.");

            return errors;
        };

        $.ajax({
            url: `/ajax/GetAllComments?postId=${postId}`,
            method: 'GET',
            dataType: 'json'
        }).done((responseStr) => {
            if (responseStr.Code === 200) {

                let comments = responseStr.Data;
                console.dir(comments);
                
                renderComments(comments, $('.comments-container'));
                
                $sendMessageForm = $('.send-message-form');
                $buttonSubmit = $sendMessageForm.find('button[type="submit"]').on('click', (e) => {
                    e.preventDefault();
                    $loginField = $sendMessageForm.find('input[name="Login"]');
                    $emailField = $sendMessageForm.find('input[name="Email"]');
                    $messageField = $sendMessageForm.find('textarea[name="Message"]');
                    let $resultBlock = $('.form-result');
                    
                    //validation!!!
                    let login = $loginField.val().trim();
                    let email = $emailField.val().trim();
                    let messageText = $messageField.val().trim();
                    
                    let errors = validateForm(login, email, messageText);

                    if (errors.length > 0) {
                        $resultBlock
                            .removeClass()
                            .addClass('form-result alert alert-danger')
                            .html(errors.join("<br>"));
                        return;
                    }
                    //


                    let message = {
                        postId: postId,
                        login: login,
                        email: email,
                        message: messageText,
                        parentId: currentParentId
                    };

                    console.log("Sending:", message);
                    
                    $.ajax({
                        url: `/ajax/saveComment`,
                        method: 'POST',
                        data: message,
                    }).done((saveCommentResultStr) => {
                        console.log(saveCommentResultStr);
                        let saveCommentResult = JSON.parse(saveCommentResultStr);

                        if (saveCommentResult.Code === 200 && saveCommentResult.Status === 1) {

                            $resultBlock
                                .removeClass()
                                .addClass('form-result alert alert-success')
                                .text(saveCommentResult.Message);

                            $loginField.val('');
                            $emailField.val('');
                            $messageField.val('');
                            currentParentId = null;

                        } else {

                            $resultBlock
                                .removeClass()
                                .addClass('form-result alert alert-danger')
                                .text(saveCommentResult.Message || "Something went wrong.");
                        }
                    
                    })
                    
                });
                

            }

        })

    });

})();