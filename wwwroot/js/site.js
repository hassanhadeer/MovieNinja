

let searchBox = document.querySelector('#searchBox');
if(searchBox != null)
    searchBox.focus();

let password1 = document.querySelector('#password1');
let password2 = document.querySelector('#password2');

function CheckPasswords() {
    if(password1.value === password2.value) {
        password2.setAttribute('style', 'background: #fff;');
    }   
    else {
        password2.value = ''; // clear the textbox
        password2.setAttribute('style', 'background: rgb(236, 247, 144);');
        password2.setAttribute('placeholder', 'passwords must match!');
        password2.focus();
    }
}