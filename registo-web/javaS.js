var myButton = document.getElementById('mouseclick');
myButton.style.height = '50px';
myButton.style.width= '100px';

function digestMessage(message) {
                        const encoder = new TextEncoder();
                        const data = encoder.encode(message);
                        return window.crypto.subtle.digest('SHA-256', data);
            }
                    
function hexString(buffer) {
          		const byteArray = new Uint8Array(buffer);

                const hexCodes = [...byteArray].map(value => {
                  const hexCode = value.toString(16);
                  const paddedHexCode = hexCode.padStart(2, '0');
                  return paddedHexCode;
                });

                return hexCodes.join('');
            }





function ClickRegistar(){
	var Fname=document.getElementById('Fname').value;
	var Lname=document.getElementById("Lname").value;
	var Address = document.getElementById("address").value;
	var PhoneNumber = document.getElementById("phoneNumber").value;
	var Bday = document.getElementById("date").value;
	var Gender = document.getElementById("gender").value;
	var Email = document.getElementById("email").value;
	var Password = document.getElementById("password").value;
	var ConfirmPass = document.getElementById("confirmpass").value;


	console.log(Fname);
	console.log(Lname);


if (Fname=="" || Lname=="" || Address=="" || PhoneNumber=="" || Bday=="" || Gender=="" || Email=="" || Password=="" || ConfirmPass=="") {
 	document.getElementById('lbltipAddedComment').innerHTML = 'missing information';
 	}
if(Password!=ConfirmPass){
		document.getElementById('lbltipAddedComment').innerHTML = 'error on password';
	}





if (Fname!="" && Lname!="" && Address!="" && PhoneNumber!="" && Bday!="" && Gender!="" && Email!="" && Password!="" &&ConfirmPass!="" && Password==ConfirmPass ){


	
	digestMessage(Password).then(digestValue => {



	const Http = new XMLHttpRequest (); 

const url = "https://hiawebservice2.azurewebsites.net/AddUser?email="+Email+"&password="+hexString(digestValue)+"&firstName="+Fname+"&lastName="+Lname+"&phoneNumber="+PhoneNumber+"&birthday="+Bday+"&gender="+Gender+"&address="+Address;
Http.open("POST", url); 
Http.send();
document.getElementById('lbltipAddedComment').innerHTML = 'registration complete';


});
}

}