new Snow();

$(document).ready(function () {
    $('.mask-phone').mask('+7 (999) 999-99-99');
});

function validatePasswords() {
    let enterPassword = document.getElementById('EnterPassword');
    let repeatPassword = document.getElementById('RepeatPassword');

    const enterPasswordValidation = document.getElementById("EnterPasswordValidation");

    if (enterPassword.value !== repeatPassword.value) {
        enterPassword.classList.add("is-invalid");
        enterPasswordValidation.innerHTML = "Пароли не совпадают";
    } else {
        enterPassword.classList.remove("is-invalid");
        enterPassword.classList.add("is-valid");
        enterPasswordValidation.innerHTML = "";
    }
}

document.getElementById("EnterPassword").addEventListener("change", validatePasswords);
document.getElementById("RepeatPassword").addEventListener("change", validatePasswords);


document.getElementById("LoginButton").addEventListener("click", function () {
    const email = document.getElementById("Email").value;
    const phone = document.getElementById("Phone").value;
    const password = document.getElementById("Password").value;
    axios.post('/Account/Login', {
        email: email,
        phone: phone,
        password: password
    })
        .then(function (response) {
            const personalAccountModal = bootstrap.Modal.getOrCreateInstance(document.querySelector("#PersonalAccountModal"));
            personalAccountModal.hide();

            const loginSuccessModal = bootstrap.Modal.getOrCreateInstance(document.querySelector("#LoginSuccessModal"));
            loginSuccessModal.show();

            const name = response.data.name;

            document.getElementById("LoginSuccesNameSpot").innerText = `${name}`;
        })
        .catch(function (error) {
            console.log(error);
        });
});

const emailButton = document.getElementById("EmailBtn");
const phoneButton = document.getElementById("PhoneBtn");
const emailWrapper = document.getElementById("EmailWrapper");
const phoneWrapper = document.getElementById("PhoneWrapper");

function showPhoneForm() {
    phoneWrapper.classList.remove("d-none");
    emailWrapper.classList.add("d-none");
    document.getElementById("Email").value = "";
}

function showEmailForm() {
    phoneWrapper.classList.add("d-none");
    emailWrapper.classList.remove("d-none");
    document.getElementById("Phone").value = "";
}

phoneButton.addEventListener("click", showPhoneForm);
emailButton.addEventListener("click", showEmailForm);

document.getElementById("RegistrationButton").addEventListener("click", function () {
    const phone = document.getElementById("PhoneRegistration").value;
    const name = document.getElementById("NameRegistration").value;
    const password = document.getElementById("EnterPassword").value;
    const email = document.getElementById("EmailRegistration").value;
    const lastname = document.getElementById("SurnameRegistration").value;
    const passwordRepetition = document.getElementById("RepeatPassword").value;
    const gender = document.getElementById("GenderRegistration").value;

    axios.post('/Account/Register', {
        PhoneNumber: phone,
        Name: name,
        LastName: lastname,
        Email: email,
        Password: password,

        IsMan: gender,

    })
        .then(function (response) {
            const personalAccountModal = bootstrap.Modal.getOrCreateInstance(document.querySelector("#PersonalAccountModal"));
            personalAccountModal.hide();

            const registrationSuccessModal = bootstrap.Modal.getOrCreateInstance(document.querySelector("#RegistrationSuccessModal"));
            registrationSuccessModal.show();
        })
        .catch(function (error) {
            console.log(error);
        });
});