$(document).ready(function () {

    $("#jscheck").keyup(function (e) {
       
        var str = $("#jscheck").val();
       
        str = str.replace(/\s/g, "");
        const len = str.length;
        var check = true;
        if (len > 0) {
            
            for (let i = 0; i < len / 2; i++) {

                if (str[i] !== str[len - 1 - i]) {
                    check = false;
                    $("#jscheck").css("background", "red");
                    break;
                }
            }
            if (check) {
                $("#jscheck").css("background", "green");
            }

        }


    });

   


    $("#csbutton").click(function (e) {
        e.preventDefault();
        var str = $("#cscheck").val();
       
        const len = str.length;
        var check = true;
        if (len > 0) {
            $.get("http://localhost:44344/api/Palindrome/CheckPalindrome?palindromeStr="+str, function (data) {
                if (data) {
                    $("#cscheck").css("background", "green");
                } else {
                    $("#cscheck").css("background", "red");
                }
              
            });
        }

    });




    $("#sqlbutton").click(function (e) {
        e.preventDefault();
        var str = $("#sqlcheck").val();
       
        const len = str.length;
        var check = true;
        if (len > 0) {
            $.get("http://localhost:44344/api/Palindrome/CheckPalindromeSql?palindromeStr=" + str, function (data) {
                if (data) {
                    $("#sqlcheck").css("background", "green");
                } else {
                    $("#sqlcheck").css("background", "red");
                }

            });
        }

    });

});