<?php
require '../config.php';
require '../database.php';
$db = new Database(HOST, USERNAME, PASSWORD, DATABASE);

// Check if the required data is provided in the POST request
if (isset($_POST['Title'], $_POST['Description'], $_POST['Position'], $_POST['Department'])) {

    $inttitle = $_POST['Title'];
    $intdesc = $_POST['Description'];
    $intdept = $_POST['Department'];
    $intpost = $_POST['Position'];
   
    $params = array(
        "location" => $inttitle,
        "int_desc" => $intdesc,
        "building_id" => $intdept,
        "int_position" => $intpost,
    );

    // Execute the insert operation and handle the response
    $id = $db->insert('interactables', $params);

    if ($id) {
        $response = array("message" => "Record added successfully", "status" => 1);
        echo json_encode($response);
    } else {
        $response = array("message" => "Error adding record: " . $db->getLastError(), "status" => 0);
        echo json_encode($response);
    }

} else {
    $response = array("message" => "Missing required data");
    echo json_encode($response);
}

?>
