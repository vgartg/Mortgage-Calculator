//Селектор кнопки, блок рассчета и блок ошибки соответственно
let button = document.querySelector('button');
let elem = document.getElementById('invis');
let er = document.getElementById('invis_er');

//Событие клика по кнопке
button.addEventListener('click', function () {

    //Стоимость недвижимости, первоначальный взнос(в рублях), первоначальный взнос(в процентах) соответственно
    let EsVal = document.getElementById('RealEstateValue').value;
    let InF = document.getElementById('AnInitialFee').value;
    let PFirstV = document.getElementById('PFirstV').value;

    //Проверка валидности ввода стоимости недвижимости и первоначального взноса(в рублях)
    if (EsVal == 0 || InF == 0) {
        //Вставка текста ошибки в поле для ошибок
        document.querySelector('.invis_er').innerHTML = 'Корректно заполните все поля!';
        //Открытие поля ошибок, закрытие поля вывода ежемесячного платежа
        er.style.visibility = 'visible';
        elem.style.visibility = 'hidden';
        //Выход из события клика по кнопке
        return;
    }

    //Проверка на то, отрицательная ли стоимость недвижимости
    if (EsVal < 0) {
        //Вставка текста ошибки в поле для ошибок
        document.querySelector('.invis_er').innerHTML = 'Стоимость недвижимости не может принимать отрицательные значения!';
        //Открытие поля ошибок, закрытие поля вывода ежемесячного платежа
        er.style.visibility = 'visible';
        elem.style.visibility = 'hidden';
        //Выход из события клика по кнопке
        return;
    }

    //Проверка на то, отрицательный ли первоначальный взнос(в рублях)
    if (InF < 0) {
        //Вставка текста ошибки в поле для ошибок
        document.querySelector('.invis_er').innerHTML = 'Первоначальный взнос не может принимать отрицательные значения!';
        //Открытие поля ошибок, закрытие поля вывода ежемесячного платежа
        er.style.visibility = 'visible';
        elem.style.visibility = 'hidden';
        //Выход из события клика по кнопке
        return;
    }

    //Проверка на то, отрицательная ли сумма кредита
    if (document.getElementById('CredSum').value < 0 || PFirstV > 100 || (InF / EsVal) > 1) {
        //Вставка текста ошибки в поле для ошибок
        document.querySelector('.invis_er').innerHTML = 'Первоначальный взнос не может быть больше стоимости недвижимости!';
        //Открытие поля ошибок, закрытие поля вывода ежемесячного платежа
        er.style.visibility = 'visible';
        elem.style.visibility = 'hidden';
        //Выход из события клика по кнопке
        return;
    }

    //Проверка валидности ввода срока кредита(от 1 года до 50 лет)
    if (document.getElementById('CreditTerm').value == 0 || document.getElementById('CreditTerm').value > 50) {
        //Вставка текста ошибки в поле для ошибок
        document.querySelector('.invis_er').innerHTML = 'Срок кредита должен находиться в диапазоне от 1 до 50 полных лет!';
        //Открытие поля ошибок, закрытие поля вывода ежемесячного платежа
        er.style.visibility = 'visible';
        elem.style.visibility = 'hidden';
        //Выход из события клика по кнопке
        return;
    }

    //Переменные для подсчета ежемесячного платежа: Сумма кредита, кол-во месяцев кредитования и процентная ставка в месяц
    let Sz = document.getElementById('CredSum').value;
    let n = document.getElementById('CreditTerm').value * 12;
    let r = (document.getElementById('interestRate').value / (100 * 12));

    /* Формула: A = Sz*r/(1-(1/(1+r)))*n, где А - ежемесячный платеж, Sz – общая сумма займа, n – количество месяцев,
    r – процентная ставка за год, разделенная на двенадцать месяцев. */
    let A = (Sz * r) / (((1 - (1 / (1 + r)))) * n);

    //Если форма валидна, то открывается блок с ежемесячным платежом и скрывается блок с ошибками
    er.style.visibility = 'hidden';
    elem.style.visibility = 'visible';

    //Вставка поссчитанного числа в форму результата в HTML-форму
    document.querySelector('.result').innerHTML = (A).toFixed(3);

    //Тело для вставки процентной ставки для POST-запроса
    const body = {
        interest_rate: document.getElementById('interestRate').value
    }

    //url-ссылка для отправки запроса
    const requestURL = "";

    //POST-запрос
    /*sendRequest('POST', requestURL, body)
        .then(data => console.log(data))
        .catch(err => console.log(err))*/
});

//Отправка запроса по url
function sendRequest(method, url, body = null) {
    const headers = {
        'Content-Type': 'application/json'
    }

    return fetch(url, {
        method: method,
        body: JSON.stringify(body),
        headers: headers
    }).then(response => {

        if (response.ok) {
            return response.json()
        }

        return response.json().then(error => {
            const e = new Error('Something went wrong...')
            e.data = error
            throw e
        })
    })
}