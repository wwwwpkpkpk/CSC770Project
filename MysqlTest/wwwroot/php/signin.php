<?php
  $email_d = $_POST["email"];
  $fpassword_d = $_POST["fpassword"];

  $conn = mysqli_connect('localhost', 'root', 'asd123', 'drunkencode') or die("Failed");
  $e_sql = "SELECT COUNT(email) as flag1 from user_account where email = '$email_d'";
  $e_result = mysqli_query($conn, $e_sql);
  $e_data = mysqli_fetch_assoc($e_result);

  $p_sql = "SELECT COUNT(fpassword) as flag2 from user_account where email = '$email_d' and fpassword = '$fpassword_d'";
  $p_result = mysqli_query($conn, $p_sql);
  $p_data = mysqli_fetch_assoc($p_result);

  if($e_data['flag1'] == 1 AND $p_data['flag2'] == 1){
    echo "<script>alert(\"Welcome\");</script>";
    echo("<script>location.replace('../index.html');</script>");
  }
  else{
    echo "<script>alert(\"Invalid Email or Password. Please check your Email or Password\");</script>";
    echo "<script>
  　　　　　　history.back()
  　　　　　</script>
  　　　　";
  }
?>
