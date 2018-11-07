<?php
  $email_d = $_POST["email"];
  $fname_d = $_POST["fname"];
  $lname_d = $_POST["lname"];
  $fpassword_d = $_POST["fpassword"];
  $rpassword_d = $_POST["rpassword"];

  $conn = mysqli_connect('localhost', 'root', 'asd123', 'drunkencode') or die("Failed");
  $sql = "SELECT COUNT(email) as flag from user_account where email = '$email_d'";
  $result = mysqli_query($conn, $sql);
  $data=mysqli_fetch_assoc($result);

  $p_flag = strcasecmp($fpassword_d, $rpassword_d); # correct = 0, incorrect = 1;
  if($data['flag'] == 1){
    echo "<script>alert(\"Your email is already exist. Please use another email address\");</script>";
    echo "<script>
  　　　　　　history.back()
  　　　　　</script>
  　　　　";
  }
  else if($p_flag < 0 OR $p_flag > 0){
    echo "<script>alert(\"Please make sure your passwords match.\");</script>";
    echo "<script>
  　　　　　　history.back()
  　　　　　</script>
  　　　　";
  }
  else if($data['flag'] == 0 AND $p_flag == 0){
    $sql = "INSERT INTO user_account (email, fname, lname, fpassword, rpassword) VALUES ('$email_d', '$fname_d', '$lname_d', '$fpassword_d','$rpassword_d')";
    mysqli_query($conn, $sql);
    echo "<script>alert(\"Welcome To Join Us\");</script>";
    echo("<script>location.replace('../signin.html');</script>");
  }
?>
