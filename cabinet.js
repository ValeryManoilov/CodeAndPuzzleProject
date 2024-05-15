document.getElementById('save').addEventListener('click', function() {
    // Собираем данные из формы
    const formData = new FormData();
    formData.append('FirstName', document.getElementById('name').value);
    formData.append('LastName', document.getElementById('sname').value);
    formData.append('Email', document.getElementById('email').value);
    formData.append('UserName', document.getElementById('username').value);
    
    // const avatarFile = document.getElementById('avatarInput').files[1];
    // formData.append('avatar', avatarFile);
    
    // Отправляем запрос на сервер
    fetch('http://localhost:5083/api/user/adduser', {
        method: 'POST',

        body: formData
    })
    .then(response => {
        if(response.ok) {
            console.log('Данные успешно отправлены на сервер');
            window.location.href = '../html/lesson.html';

        } else {
            console.error('Ошибка при отправке данных на сервер');
        }
    })
    .catch(error => {
        console.error('Произошла ошибка:', error);
    });
});
