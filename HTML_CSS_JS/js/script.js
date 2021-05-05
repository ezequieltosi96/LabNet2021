const form = document.getElementById("contact-form");
const firstName = document.querySelector('input[name="first_name"]');
const lastName = document.querySelector('input[name="last_name"]');
const age = document.querySelector('input[name="age"]');
const companyName = document.querySelector('input[name="company_name"]');

form.addEventListener("submit", (event) => {
    event.preventDefault();

    hideValidationErrors();
    const shouldSubmit = validateForm();

    if (shouldSubmit) {
        logFormDataInJsonFormat();
        clearForm();
        toast("Submitted and logged into explorer console...");
    }
    else {
        toast("Check for errors...");
    }
});

const logFormDataInJsonFormat = () => {
    const gender = document.querySelector('input[name="gender"]:checked').value;

    const formData = JSON.parse(`{"firstName":"${firstName.value}","lastName":"${lastName.value}", "age":"${age.value}", "gender":"${gender}", "companyName":"${companyName.value}"}`);

    console.log(formData);
}

const handleClearForm = () => {
    clearForm();
    toast("Form cleared successfully...");
};

const clearForm = () => {
    form.reset();
    hideValidationErrors();
};

const toast = (message) => {
    const toastContainer = document.getElementById("toast");

    toastContainer.innerHTML = message;
    toastContainer.className = "show";

    setTimeout(() => {
        toastContainer.className = toastContainer.className.replace("show", "");
    },
        4000);
};

const hideValidationErrors = () => {
    const validators = document.querySelectorAll('span.validator');

    validators.forEach(element => {
        element.hidden = true;
    });

    firstName.classList.remove('input-error');
    lastName.classList.remove('input-error');
    age.classList.remove('input-error');
    companyName.classList.remove('input-error');
};

const validateForm = () => {
    let valid = true;

    if (!isValid(firstName.value)) {
        var firstNameValidator = document.getElementById("first_name_validator");
        firstNameValidator.hidden = false;
        firstName.classList.toggle("input-error");
        valid = false;
    }
    if (!isValid(lastName.value)) {
        var lastNameValidator = document.getElementById("last_name_validator");
        lastNameValidator.hidden = false;
        lastName.classList.toggle("input-error");
        valid = false;
    }
    if (!isValid(age.value)) {
        var ageNameValidator = document.getElementById("age_validator");
        ageNameValidator.hidden = false;
        age.classList.toggle("input-error");
        valid = false;
    }
    if (!isValid(companyName.value)) {
        var companyNameValidator = document.getElementById("company_name_validator");
        companyNameValidator.hidden = false;
        companyName.classList.toggle("input-error");
        valid = false;
    }

    return valid;
};

const isValid = (property) => {
    if (property === "") {
        return false;
    }
    return true;
};