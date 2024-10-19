document.getElementById("EnterPassword").addEventListener("change", validatePasswords);
document.getElementById("RepeatPassword").addEventListener("change", validatePasswords);

function validatePasswords() {
    var enterPassword = document.getElementById('EnterPassword');
    var repeatPassword = document.getElementById('RepeatPassword');

    const enterPasswordValidation = document.getElementById("EnterPasswordValidation");
    const confirmPasswordValidation = document.getElementById("ConfirmPasswordValidation");

    if (enterPassword.value !== repeatPassword.value) {
        enterPassword.classList.add("is-invalid");
        enterPasswordValidation.innerHTML = "Пароли не совпадают";
    } else {
        enterPassword.classList.remove("is-invalid");
        enterPassword.classList.add("is-valid");
        enterPasswordValidation.innerHTML = "";
    }
}

document.getElementById("Login").addEventListener("click", function () {
    const email = document.getElementById("Email").value;
    const phone = document.getElementById("Phone").value;
    const password = document.getElementById("Password").value;
    axios.post('/api/Account/Login', {
        email: email,
        phone: phone,
        password: password
    })
        .then(function (response) {
            const personalAccountModal = new bootstrap.Modal('#PersonalAccountModal', {
                keyboard: false
            })
            personalAccountModal.hide();

            const loginSuccessModal = new bootstrap.Modal('#LoginSuccessModal', {
                keyboard: false
            })
            loginSuccessModal.show();
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

document.getelementbyid("Registration").addeventlistener("click", function () {
    const email = document.getelementbyid("Email").value;
    const phone = document.getelementbyid("Phone").value;
    const password = document.getelementbyid("Password").value;

    axios.post('/api/account/Login', {
        email: email,
        phone: phone,
        password: password
    })
        .then(function (response) {
            const personalaccountmodal = new bootstrap.modal('#PersonalAccountModal', {
                keyboard: false
            })
            personalaccountmodal.hide();

            const loginsuccessmodal = new bootstrap.modal('#LoginSuccessModal', {
                keyboard: false
            })
            loginsuccessmodal.show();
        })
        .catch(function (error) {
            console.log(error);
        });
});