<?php
session_start();
require "../config.php";
require "../database.php";

$db = new Database(HOST, USERNAME, PASSWORD, DATABASE);

$updateData = array(
    "status" => $_POST['status']
   
);

   if ($db->update("buildings", $updateData,"id ='".$_POST["id"]."'")) {
    $response['status'] = 'Success';
    switch($_POST['status']){
        case 'Active':
            $response['message'] = "Restored";
            break;
            case 'Trash':
                $response['message'] = "Moved to trash.";
                break;
    }
    }else{
        $response['message'] = "Error deleting record: ";
        $response['status'] = "Error";
    }


    
$json_response = json_encode($response);
echo $json_response;
?>