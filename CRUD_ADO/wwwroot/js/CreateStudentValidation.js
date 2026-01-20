function isValidEmail(email) {
    const emailRegex = /^[a-zA-Z0-9._]+@[a-zA-Z0-9]+\.[a-zA-Z]{2,}$/;

    return emailRegex.test(email) && email.length < 30;
}

function validateForm() {


        let isValidAllFields = true;

        let phone = $("#phone").val().trim();
        let email = $("#email").val().trim();

        $('.text-danger').text("");

        if (!/^[789]\d{9}$/.test(phone)) {
            $("#phoneError").text("Phone digit number must be of 10 digits starting with 7 ,8,9");
            isValidAllFields = false;
        }

        if (!isValidEmail(email)) {
            $("#emailError").text("Invalid Email")
            isValidAllFields = false;
        }


        return isValidAllFields;
           

}