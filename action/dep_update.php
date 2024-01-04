<?php
require '../config.php';
require '../database.php';
$db = new Database(HOST, USERNAME, PASSWORD, DATABASE);

if ($_SERVER["REQUEST_METHOD"] == "POST") {
    // Check if the required data is provided in the POST request
    if (isset($_POST['Interactableid'], $_POST['Description'], $_POST['Active'], $_POST['Style'])) {
        
        $intID = $_POST['Interactableid'];
        $int_desc = $_POST['Description'];
        $intact = $_POST['Active'];
        $intsty = $_POST['Style'];
     
        
        $params = array(
            "description" => $int_desc, 
            "map_active" =>  $intact, 
            "map_style" => $intsty, 
        );
    
        // Execute the update operation and handle the response
        $result = $db->update('buildings', $params, 'id = '.$intID);

        if ($result) {
            $response = array("message" => "Record updated successfully", "status" =>1);
            echo json_encode($response);
        } else {
            $response = array("message" => "Error updating record");
            echo json_encode($response);
        }
        
    } else {
        $response = array("message" => "Missing required data - POST Data: " . json_encode($_POST));
        echo json_encode($response);

        echo json_encode($response);
    }
} else {
    $response = array("message" => "Method not allowed");
    echo json_encode($response);
}
?>
