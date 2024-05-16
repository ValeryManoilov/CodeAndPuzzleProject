const password = document.getElementById("password")
const username = document.getElementById("email")
const button = document.getElementById("vxod")

button.addEventListener('click', () => {
    fetch('http://localhost:5083/swagger/api/user/login', {
    method: 'POST',
    body: JSON.stringify({
    email: username.value,
    password: password.value
    }),
    headers: {
    'Content-type': 'application/json',
    }
    }).then(response => {
        if (response.status == "200"){
            localStorage.setItem('isLoggedIn', 'true');
            window.location.href='cabinet.html';
            window.localStorage.setItem('username', document.getElementById("email").value);
        }
        else {
            const errorMessage = document.createElement('p');
            errorMessage.textContent = 'Неверный логин или пароль';
            errorMessage.style.color = 'red';
            button.insertAdjacentElement('beforebegin', errorMessage);
            
        }
    })
})

// const password = document.getElementById("password");
// const username = document.getElementById("email");
// const button = document.getElementById("vxod");

// button.addEventListener('click', () => {
//     const formData = new FormData();
//     formData.append('username', username.value);
//     formData.append('password', password.value);

//     fetch('http://localhost:5083/swagger/api/user/login', {
//         email: 'POST',
//         body: formData
//     }).then(response => {
//         if (response.status === 200){
//             localStorage.setItem('isLoggedIn', 'true');
//             window.location.href = 'cabinet.html';
//             window.localStorage.setItem('username', document.getElementById("email").value);
//         }
//         else {
//             const errorMessage = document.createElement('p');
//             errorMessage.textContent = 'Неверный логин или пароль';
//             errorMessage.style.color = 'red';
//             button.insertAdjacentElement('beforebegin', errorMessage);
//         }
//     });
// });

