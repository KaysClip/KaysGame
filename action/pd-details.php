<?php
session_start();
require "../config.php";
require "../database.php";

$db = new Database(HOST, USERNAME, PASSWORD, DATABASE);

$records = $db->Select("interactables", "*", "id=". $_POST['id']); 

$response['int_id'] = $records[0]['int_id'];
$response['int_title'] = $records[0]['int_title'];
$response['int_desc'] = $records[0]['int_desc'];
$response['coordinateX'] = $records[0]['coordinateX'];
$response['coordinateY'] = $records[0]['coordinateY'];
$response['coordinateZ'] = $records[0]['coordinateZ'];


echo json_encode($response);
?>