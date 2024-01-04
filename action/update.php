<?php
require '../config.php';
require '../database.php';
$db = new Database(HOST, USERNAME, PASSWORD, DATABASE);

if ($_SERVER["REQUEST_METHOD"] == "POST") {
    // Check if the required data is provided in the POST request
    if (isset($_POST['Description'], $_POST['Position'], $_POST['Interactableid'])) {

       
        $intdesc = $_POST['Description'];
        $intpost = $_POST['Position'];
        $intid = $_POST['Interactableid'];
       
        $params = array(
            "int_desc" => $intdesc,
            "int_position" => $intpost,
        );

        // Assuming 'update' method in Database class executes the query
        $result = $db->update('interactables', $params, 'int_id = '.$intid);

        if ($result) {
            $response = array("message" => "Record updated successfully", "status" =>1);
            echo json_encode($response);
        } else {
            $response = array("message" => "Error updating record");
            echo json_encode($response);
        }
        
    } else {
        $response = array("message" => "Missing required data".json_encode($_POST));
        echo json_encode($response);
    }
} else {
    $response = array("message" => "Method not allowed");
    echo json_encode($response);
}
?>
