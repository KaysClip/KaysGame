<?php
require __DIR__ . '/../config.php';
require __DIR__ . '/../database.php';

function getTrashedBuildings() {
    $conn = new mysqli(HOST, USERNAME, PASSWORD, DATABASE);

    if ($conn->connect_error) {
        die("Connection failed: " . $conn->connect_error);
    }

    $sql = "SELECT * FROM buildings WHERE status = 1"; // 'status = 1' represents 'trashed'
    $result = $conn->query($sql);

    if (!$result) {
        die("Query failed: " . $conn->error);
    }

    $buildings = [];

    if ($result->num_rows > 0) {
        while ($row = $result->fetch_assoc()) {
            $buildings[] = $row;
        }
    }

    $conn->close();
    return $buildings;
}

if ($_SERVER['REQUEST_METHOD'] === 'GET') {
    $trashedBuildings = getTrashedBuildings();

    if (!empty($_SERVER['HTTP_X_REQUESTED_WITH']) && strtolower($_SERVER['HTTP_X_REQUESTED_WITH']) == 'xmlhttprequest') {
        // AJAX request, return JSON
        header('Content-Type: application/json');
        echo json_encode($trashedBuildings);
        exit();
    } else {
        // Regular request, generate HTML
        foreach ($trashedBuildings as $row) {
            ?>
           <tr data-id="<?php echo $row["id"]; ?>">
            <td><?php echo $row['id']; ?></td>
            <td><?php echo $row["name"]; ?></td>
            <td><?php echo $row["description"]; ?></td>
            <td>
                <?php echo implode(' ', array_slice(explode(' ', $row['map_active']), 0, 12)); ?>
            </td>
            <td><?php echo $row["map_style"]; ?></td>
            <td>
                <div class="button-container dropdown">
                    <button class="btn btn-link" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <i class="bi bi-list" style="color: #000; font-size: 18px;"></i>
                    </button>
                    <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                        <button intname1="<?php echo $row['name']; ?>" intact1="<?php echo $row['map_active']; ?>" intstyle1="<?php echo $row['map_style']; ?>" intdesc1="<?php echo $row['description']; ?>" type="button" data-interactableid="<?php echo $row['id']; ?>" class="dropdown-item retrieve">
                            <i class="bi bi-pencil-square" style="color: #4CAF50;"></i> Retrieves
                        </button>
                       <button type="button" data-interactableid="<?php echo $row['id']; ?>" class="dropdown-item remove">
                            <i class="bi bi-trash" style="color: #F44336;"></i> Delete buildings
                        </button> 
                         <!--<a href="" class="change-status dropdown-item text-secondary" data-status="Trash" data-id="<?php echo $row['id']; ?>" data-redirect="<?php echo BASE; ?>/department.php" data-action="<?php echo BASE; ?>/action/change-status.php"><i  class="bi bi-trash" style="color: #F44336;"></i><span class="ml-2">Trash</span></a>-->
                    </div>
                </div>
            </td>
        </tr>
            <?php
        }
    }
}
?>
