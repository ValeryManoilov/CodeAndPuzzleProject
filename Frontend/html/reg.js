const password = document.getElementById("password");
const confirmPassword = document.getElementById("passwordpovtor");
const username = document.getElementById("email");
const button = document.getElementById("zaregistr");

button.addEventListener('click', () => {
    if (password.value !== confirmPassword.value) {
        const errorMessage = document.createElement('p');
        errorMessage.textContent = 'Пароли не совпадают';
        errorMessage.style.color = 'red';
        button.insertAdjacentElement('beforebegin', errorMessage);
        return;
    }

    const formData = new FormData();
    formData.append('Email', username.value);
    formData.append('Password', password.value);
    console.log(username.value)
    console.log(password.value)

    fetch(`http://localhost:5083/api/user/register?email=${username.value}&password=${password.value}`, {
        method: 'POST',
        // body: JSON.stringify({
        //     Email: username.value,
        //     Password: password.value
        // }),
        headers: {
            'Access-Control-Allow-Origin': "*",
            "Content-Type": "application/json",
          },
    })
    .then(response => {
        localStorage.setItem('isLoggedIn', 'true');
        // window.location.href = 'cabinet.html';
        window.localStorage.setItem('username', document.getElementById("email").value);
        console.log(response)
    })
    .catch(response => {
        const errorMessage = document.createElement('p');
        errorMessage.textContent = 'Не удалось зарегистрироваться. Попробуйте еще раз.';
        errorMessage.style.color = 'red';
        button.insertAdjacentElement('beforebegin', errorMessage);
        console.log(response.status)
    });
});

// const password = document.getElementById("password");
// const confirmPassword = document.getElementById("passwordpovtor");
// const username = document.getElementById("email");
// const button = document.getElementById("vxod");

// button.addEventListener('click', () => {
//     if (password.value !== confirmPassword.value) {
//         const errorMessage = document.createElement('p');
//         errorMessage.textContent = 'Пароли не совпадают';
//         errorMessage.style.color = 'red';
//         button.insertAdjacentElement('beforebegin', errorMessage);
//         return;
//     }

//     fetch('http://localhost:5083//swagger/api/user/adduser', {
//         method: 'POST',
//         body: JSON.stringify({
//             username: username.value,
//             password: password.value
//         }),
//         headers: {
//             'Content-type': 'application/json',
//         }
//     }).then(response => {
//         if (response.status === 200) {
//             localStorage.setItem('isLoggedIn', 'true');
//             window.location.href = '../html/cabinet.html';
//             window.localStorage.setItem('username', document.getElementById("email").value);
//         } else {
//             const errorMessage = document.createElement('p');
//             errorMessage.textContent = 'Не удалось зарегистрироваться. Попробуйте еще раз.';
//             errorMessage.style.color = 'red';
//             button.insertAdjacentElement('beforebegin', errorMessage);
//         }
//     });
// });