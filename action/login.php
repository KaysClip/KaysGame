<?php
session_start();
require "../config.php";
require "../database.php";


$db = new Database(HOST, USERNAME, PASSWORD, DATABASE);


if($_POST['FirstName'] && $_POST['Password']){

    $row = $db->Select("user", "*", "FirstName='". $_POST['FirstName']."'"); 
    
    if(count($row)){
       
        $verify = password_verify($_POST['Password'], $row[0]['Password']);
  
        if ($verify) {
            $_SESSION['user_id'] = $row[0]['Userid'];
            $_SESSION['fulname'] = $row[0]['FirstName'].' '.$row[0]['LastName'];
            $response['message'] = 'Password Verified!';
        } else {
            $response['message'] = 'Incorrect Password!';
        }
      

    }else{
        $response['message'] = 'Invalid Username!';
    }

}else{
    $response['message'] = 'Username and Password are required.';
}


$json_response = json_encode($response);
echo $json_response;
?>