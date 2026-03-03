    (() => {

    window.addEventListener('load', () => {

        let $commBlock = $('.card-body');
        let postId = $('.one-post-id').text();
        
        let getOneComment = (oneComm) => {
            
            let childComm = getCommentsChilds(oneComm);

            let comm = `
                    <div class="d-flex mb-4">
                        <img src="${oneComm.Avatar}" 
                             alt="avatar" 
                             class="class="rounded-circle shadow-sm me-4""
                             width="45" height="45" />
                    
                        <div class="flex-grow-1">
                    
                            <div class="d-flex justify-content-between align-items-center">
                                <div>
                                    <span class="fw-semibold">${oneComm.Login}</span>
                                    <small class="text-muted ms-2">
                                        ${new Date(oneComm.DateOfPublished).toLocaleDateString()}
                                    </small>
                                </div>
                    
                                <a href="#!" class="text-primary small text-decoration-none">
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
                `<div class="d-flex mb-4 mt-3">
                    <img src="${childComm.Avatar}" alt="avatar" class="rounded-circle shadow-sm me-4" width="40" height="40" />
                    <div class="flex-grow-1">
                        <p class="mb-0 fw-semibold">${childComm.Login} <small class="text-muted ms-2">- ${childComm.DateOfPublished}</small></p>
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
            comments.forEach((comment, index) => {
                $parent.append(getOneComment(comment));
            })
        }

        $.ajax({
            url: `/ajax/GetAllComments?postId=${postId}`,
            method: 'GET',
            dataType: 'json'
        }).done((responseStr) => {
            // let respdata = JSON.parse(responseStr);
            if (responseStr.Code === 200) {

                let comments = responseStr.Data;
                console.dir(comments);
                
                renderComments(comments, $('.comments-container'));

            }

        })

    });

})();