<?php
  $DB_ADDR = "localhost";
  $DB_USER = "root";
  $DB_PW = "asd123";
  $DB_NAME = "drunkencode";

  $conn = mysqli_connect('$DB_ADDR', '$DB_USER', '$DB_PW', '$DB_NAME') or die("DB Connection Error :".mysqli_connect_error());
?>
