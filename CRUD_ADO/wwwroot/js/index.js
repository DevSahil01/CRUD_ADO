function EditFunc(e,id) {
    const editButton = document.getElementById(e.target.id);
 
    const studentObj = student.filter((std) => std.Id === id);
 
    

    if (editButton.innerText === "Save") {
        document.getElementById("updateData-" + e.target.id).submit();
        //alert("form is submitting ")
        return; 

    }
    else if (editButton.innerText === "Edit") {
        let editableElements = document.getElementsByClassName("editable-" + e.target.id);
        for (let i = 0; i < editableElements.length; i++) {
            editableElements[i].parentElement.classList.remove("d-none");

            editableElements[i].classList.remove("d-none");
            editableElements[i].classList.add("d-block");
        }

        let nonEditableElements = document.getElementsByClassName("not-editable-" + e.target.id);

        for (let i = 0; i < nonEditableElements.length; i++) {
            nonEditableElements[i].classList.add("d-none");
        }

        setGenderDropdown(studentObj[0].Id, studentObj[0].Gender);
        GetDepartments(studentObj[0].Id, studentObj[0].DepartmentName);


        editButton.innerText = "Save";
    }
   

}

function GetDepartments(id,deptName) {

    $.ajax({
        url: "/Student/getDepartments",
        type: "GET",
        success: function (data) {
            let ddl = $(`#DepartmentId-${id}`);
            ddl.append('<option value="" > Select Department </option> ');



            $.each(data, function (i, d) {
                let selected = deptName === d.deptName ? 'selected' : "";
                ddl.append(`<option value="${d.deptId}" ${selected}> ${d.deptName} </option > `)
            });
        }

    });
}


function setGenderDropdown(id, gender) {
    $(`#gender-${id}`).val(gender.trim());
}





