// input validation
// $("#formValidation").validate({
//   rules:{
//     name:{
//       minlength: 2
//     }
//   },
//   messages: {
//     name:{
//       required: "لطفا فرم را تکمیل بفرمایید",
//     },
//     name2:{
//       required: "لطفا فرم را تکمیل بفرمایید",
//     },
//     number:{
//       required: "لطفا فرم را تکمیل بفرمایید",
//     },
//     number2:{
//       required: "لطفا فرم را تکمیل بفرمایید",
//     },
//     date:{
//       required: "لطفا فرم را تکمیل بفرمایید",
//     },
//     exampleRadios:{
//       required: "لطفا فرم را تکمیل بفرمایید",
//     },
//     mager:{
//       required: "لطفا فرم را تکمیل بفرمایید",
//     },
//     education:{
//       required: "لطفا فرم را تکمیل بفرمایید",
//     },
//     resume:{
//       required: "لطفا رزومه خود را وارد کنید",
//     },
//     salary:{
//       required: "لطفا حقوق درخواستی را وارد کنید",
//     },
//     datee:{
//       required: "لطفا  تاریخ را وارد کنید",
//     }
//   },
//   submitHandler: function(form) {
//     form.submit();
//   }
//  });


//modal submit
// const myModal = document.querySelector('.modal');
//     let showModal = function(){
//     myModal.style.display = 'block';
//     myModal.style.transition = '.3s all ease-in-out';
//    }
//    function hideBox(){
//        myModal.style.display = 'none';
//    }

//
$("#submit").click(function(){
  var name = $("#name").val();
  var familyName = $("#familyName").val();
  var id = $("#id").val();
  var birthDate = $("#birthDate").val();
  var phone = $("#phone").val();
  var education = $("#education").val();
  var mager = $("#mager").val();
  var martialStatus = $("#martialStatus").val();
  var newSalary = $("#newSalary").val();
  var signDate = $("#signDate").val();
  var resume = $("#resume").val();

  if(name == '' || familyName == '' || id =='' || birthDate == '' || phone == '' || education == '' || mager == '' || martialStatus =='' || newSalary =='' || signDate =='' || resume == ''){
    swal({
      title: "فیلدها خالی می باشند",
      text: "لطفا موارد ستاره دار را تکمیل بفرمایید",
      icon: "warning",
      button:"باشه"
    });
  }else{
    swal({
      title: "اطلاعات شما با موفقیت ثبت گردید",
      icon: "success",
      button:"باشه"
    });
    // window.location.assign("des.html");
  }
});

///calendar
jalaliDatepicker.startWatch();

   
  