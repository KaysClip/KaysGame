<?php
require '../config.php';
require '../database.php';
$db = new Database(HOST, USERNAME, PASSWORD, DATABASE);

// Check if the required data is provided in the POST request
if (isset($_POST['Building'], $_POST['Description'], $_POST['Active'], $_POST['Style'])) {

    $int_title = $_POST['Building'];
    $int_desc = $_POST['Description'];
    $intact = $_POST['Active'];
    $intsty = $_POST['Style'];


    $params = array(
        "name" => $int_title, 
        "description" => $int_desc, 
        "map_active" =>  $intact, 
        "map_style" => $intsty, 
    );

    $id = $db->insert('buildings', $params);

    if ($id) {
        $response = array("message" => "Record added successfully", "status" => 1);
        echo json_encode($response);
    } else {
        $response = array("message" => "Error adding record: ");
        echo json_encode($response);
    }

} else {
    $response = array("message" => "Missing required data");
    echo json_encode($response);
}

?>
