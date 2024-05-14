const password = document.getElementById("password");
const confirmPassword = document.getElementById("passwordpovtor");
const username = document.getElementById("email");
const button = document.getElementById("vxod");

button.addEventListener('click', () => {
    if (password.value !== confirmPassword.value) {
        const errorMessage = document.createElement('p');
        errorMessage.textContent = 'Пароли не совпадают';
        errorMessage.style.color = 'red';
        button.insertAdjacentElement('beforebegin', errorMessage);
        return;
    }

    fetch('http://localhost:3000/register', {
        method: 'POST',
        body: JSON.stringify({
            username: username.value,
            password: password.value
        }),
        headers: {
            'Content-type': 'application/json',
        }
    }).then(response => {
        if (response.status === 200) {
            localStorage.setItem('isLoggedIn', 'true');
            window.location.href = '../html/cabinet.html';
            window.localStorage.setItem('username', document.getElementById("email").value);
        } else {
            const errorMessage = document.createElement('p');
            errorMessage.textContent = 'Не удалось зарегистрироваться. Попробуйте еще раз.';
            errorMessage.style.color = 'red';
            button.insertAdjacentElement('beforebegin', errorMessage);
        }
    });
});