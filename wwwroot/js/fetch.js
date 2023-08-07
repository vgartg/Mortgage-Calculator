const requestURL = "";
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

const body = {
    name: 'Valera',
    age: 18
}

//POST-запрос
SendRequest('POST', requestURL, body)
    .then(data => console.log(data))
    .catch(err => console.log(err))