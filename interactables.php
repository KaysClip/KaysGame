<!DOCTYPE html>
<html lang="en">

<head>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Tornare</title>

    <!-- Custom fonts for this template -->
    <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">
    <link
        href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i"
        rel="stylesheet">
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.1/font/bootstrap-icons.css">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/sweetalert2@11/dist/sweetalert2.min.css">

    <!-- Custom styles for this template -->
    <link href="css/sb-admin-2.css" rel="stylesheet">

    <!-- Custom styles for this page -->
    <link href="vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet">

</head>

<body id="page-top">

    <!-- Page Wrapper -->
    <div id="wrapper">

        <!-- Sidebar -->
        <ul class="navbar-nav bg-gradient-primary sidebar sidebar-dark accordion" id="accordionSidebar">

            <!-- Sidebar - Brand -->
            <a class="sidebar-brand d-flex align-items-center justify-content-center" href="index.php">
                <div class="sidebar-brand-icon rotate-n-15">
                    <i class=""></i>
                    </div>
                <div class="sidebar-brand-text mx-3">Tornare</div>
            </a>


            <!-- Divider -->
            <hr class="sidebar-divider my-0">

            <!-- Nav Item - Dashboard -->
            <li class="nav-item">
    <a class="nav-link" href="index.php">
        <i class="fas fa-chart-line"></i>
        <span>Dashboard</span>
    </a>
</li>
<hr class="sidebar-divider">

<li class="nav-item">
    <a class="nav-link" href="department.php">
        <i class="fas fa-building"></i>
        <span>Buildings</span>
    </a>
</li>
<hr class="sidebar-divider">

<!-- Nav Item - Tables -->
<li class="nav-item active">
    <a class="nav-link" href="interactables.php">
        <i class="fas fa-hand-pointer"></i>
        <span>Interactables</span>
    </a>
</li>
<hr class="sidebar-divider">

<li class="nav-item">
    <a class="nav-link" href="about.php">
        <i class="fas fa-info-circle"></i>
        <span>About</span>
    </a>
</li>
         
            <!-- Divider -->
            <hr class="sidebar-divider d-none d-md-block">

            <!-- Sidebar Toggler (Sidebar) -->
            <div class="text-center d-none d-md-inline">
                <button class="rounded-circle border-0" id="sidebarToggle"></button>
            </div>

        </ul>
        <!-- End of Sidebar -->

        <!-- Content Wrapper -->
        <div id="content-wrapper" class="d-flex flex-column">

            <!-- Main Content -->
            <div id="content">

                <!-- Topbar -->
                <nav class="navbar navbar-expand navbar-light bg-white topbar mb-4 static-top shadow">

                    <!-- Sidebar Toggle (Topbar) -->
                    <form class="form-inline">
                        <button id="sidebarToggleTop" class="btn btn-link d-md-none rounded-circle mr-3">
                            <i class="fa fa-bars"></i>
                        </button>
                    </form>
                

                    <!-- Topbar Navbar -->
                    <ul class="navbar-nav ml-auto">

                        <!-- Nav Item - Search Dropdown (Visible Only XS) -->
                        <li class="nav-item dropdown no-arrow d-sm-none">
                            <a class="nav-link dropdown-toggle" href="#" id="searchDropdown" role="button"
                                data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <i class="fas fa-search fa-fw"></i>
                            </a>
                            <!-- Dropdown - Messages -->
                            <div class="dropdown-menu dropdown-menu-right p-3 shadow animated--grow-in"
                                aria-labelledby="searchDropdown">
                                <form class="form-inline mr-auto w-100 navbar-search">
                                    <div class="input-group">
                                        <input type="text" class="form-control bg-light border-0 small"
                                            placeholder="Search for..." aria-label="Search"
                                            aria-describedby="basic-addon2">
                                        <div class="input-group-append">
                                            <button class="btn btn-primary" type="button">
                                                <i class="fas fa-search fa-sm"></i>
                                            </button>
                                        </div>
                                    </div>
                                </form>
                            </div>
                        </li>

                        

                        <!-- Nav Item - User Information -->
                        <li class="nav-item dropdown no-arrow">
                            <a class="nav-link dropdown-toggle" href="#" id="userDropdown" role="button"
                                data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <span class="mr-2 d-none d-lg-inline text-gray-600 small">Admin</span>
                                <img class="img-profile rounded-circle"
                                    src="img/undraw_profile.svg">
                            </a>
                            <!-- Dropdown - User Information -->
                            <div class="dropdown-menu dropdown-menu-right shadow animated--grow-in"
                                aria-labelledby="userDropdown">
                              
                                <a class="dropdown-item" href="Login.php" data-toggle="modal" data-target="#logoutModal">
                                    <i class="fas fa-sign-out-alt fa-sm fa-fw mr-2 text-gray-400"></i>
                                    Logout
                                </a>
                            </div>
                        </li>

                    </ul>
                  

                </nav>
                <!-- End of Topbar -->

                <!-- Begin Page Content -->
                <div class="container-fluid">

              
                            <div class="clearfix" style="height:50px;"></div>
                           
           

<!-- Button trigger modal -->


<!-- Modal -->
<div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabel">Add interactable</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
    <form id="frmDestination" class="col-12 col-lg-auto mb-3 mb-lg-0 me-lg-3" role="search" data-bs-theme="light">
    <div class="mb-3">
    <!-- Hidden input field for Interactableid -->
    <input type="hidden" class="form-control" name="Interactableid" placeholder="Interactable ID" aria-label="Interactableid" id="Interactableid">
</div>  
        <div class="mb-3">
            <label for="Title" class="form-label">Title:</label>
            <input type="text" class="form-control" name="Title" placeholder="Title" aria-label="Title" id="Title">
        </div>

        <div class="mb-3">
    <label for="Department" class="form-label">Department:</label>
    <select name="Department" class="form-control" aria-label="Department" id="Department">
    <option value="">Loading departments...</option>
    </select>
</div>



        <div class="mb-3">
    <label for="title" class="form-label">Positions: (X, Y, Z)</label>
    <div style="display: flex;">
    <input type="text" class="form-control" name="Position" placeholder="Position" aria-label="Position" id="Position">
    </div>
   
        </div>
        <div class="mb-3">
            <label for="description" class="form-label">Description:</label>
            <textarea class="form-control" name="Description" placeholder="Description" aria-label="Description" id="Description" rows="5"></textarea>
        </div>
    </form>
</div>
<div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        <button type="submit" class="btn btn-secondary" id="save" name="save">Save</button>
    </div>
        </div>
    </div>
</div>

<div class="card shadow mb-4">
    <div class="card-header py-3">
    <button type="button" class="Add btn btn-secondary add-building" data-toggle="modal" data-target="#exampleModal" aria-label="Add Building" aria-labelledby="addBuildingBtn">
      Add interactables +
    </button>
    <div class="button-container">

    <a href="interactables.php" title="Show All" class="btn show-all">
        Show All
    </a>

    |
    <button type="button" title="Deleted Items" class="btn show-trashed">
        Trashed Items
    </button>
</div>

  </div>
  <div class="card-body">
    <div class="table-responsive">
    <table class="table table-bordered table-hover" id="dataTable" width="100%" cellspacing="0">
            <thead class="table-light">
                <tr>
                    <th scope="col">Interactable ID</th>
                    <th scope="col">Name</th>
                    <th scope="col">Description</th>
                    <th scope="col">Position</th>
                    <th scope="col">Department</th>
                    <th scope="col" style="text-align: center;">Action</th>
                </tr>
            </thead>
            <tbody>
                <?php require('action/view.php'); ?>
            </tbody>
            <tfoot>
                <tr>
                    <th>Interactable ID</th>
                    <th>Name</th>
                    <th>Description</th>
                    <th>Position</th>
                    <th>Department</th>
                    <th>Action</th>
                </tr>
            </tfoot>
        </table>
    </div>
</div>


<style>
    body {
        font-family: 'Source Sans Pro', sans-serif; /* Use Source Sans Pro font as the primary font */ /* Additional styles can be added here */
        font-size: 14px; /* Example: setting a default font size */
    }
</style>

    

            <!-- Footer -->
            <footer class="sticky-footer bg-white">
                <div class="container my-auto">
                    <div class="copyright text-center my-auto">
                        <span>Copyright &copy; Your Website 2020</span>
                    </div>
                </div>
            </footer>
            <!-- End of Footer -->

        </div>
        <!-- End of Content Wrapper -->

    </div>
    <!-- End of Page Wrapper -->

    <!-- Scroll to Top Button-->
    <a class="scroll-to-top rounded" href="#page-top">
        <i class="fas fa-angle-up"></i>
    </a>

    <!-- Logout Modal-->
    <div class="modal fade" id="logoutModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
        aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Ready to Leave?</h5>
                    <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                </div>
                <div class="modal-body">Select "Logout" below if you are ready to end your current session.</div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
                    <a class="btn btn-primary" href="login.php">Logout</a>
                </div>
            </div>
        </div>
    </div>

    <!-- Bootstrap core JavaScript-->
    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <!-- Core plugin JavaScript-->
    <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

    <!-- Custom scripts for all pages-->
    <script src="js/sb-admin-2.js"></script>

    <!-- Page level plugins -->
    <script src="vendor/datatables/jquery.dataTables.min.js"></script>
    <script src="vendor/datatables/dataTables.bootstrap4.min.js"></script>

    <!-- Page level custom scripts -->
    <script src="js/demo/datatables-demo.js"></script>

    <!-- TORNARE TEST SCRIPTS-->
    <script src="vendor/tornaretesting/tornaretest.js"></script>
    <script src="css/table.css"></script>

    <script src="js/search.js"></script>
    <script src="js/map.js"></script>
    <script src="js/interactable.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11/dist/sweetalert2.all.min.js"></script>
    <script src="https://cdn.datatables.net/1.11.5/js/jquery.dataTables.min.js"></script>
    <!-- tinymce -->
  <script src="https://cdn.tiny.cloud/1/eddtr59ie23wi3xx284hu3ib0l3icyv1jlkuyxwua1w2obo8/tinymce/6/tinymce.min.js" referrerpolicy="origin"></script>
  

<script>
    $(function () {
    loadDepartment('<?php echo $_GET['id'];?>');
    });  

</script>

<script>
    tinymce.init({
selector: 'textarea#Description',
height: '280px',
  // plugins: 'ai tinycomments mentions anchor autolink charmap codesample emoticons image link lists media searchreplace table visualblocks wordcount checklist mediaembed casechange export formatpainter pageembed permanentpen footnotes advtemplate advtable advcode editimage tableofcontents mergetags powerpaste tinymcespellchecker autocorrect a11ychecker typography inlinecss forecolor', // Include the 'forecolor' plugin
toolbar: 'undo redo | fontfamily fontsize | forecolor| bold italic underline| link | align lineheight | numlist bullist indent outdent | removeformat', // Add the 'forecolor' button to the toolbar
forecolor_map: ['#ff0000', '#00ff00', '#0000ff'], // Define the color options
tinycomments_mode: 'embedded',
 tinycomments_author: 'Author name',
menubar: false,
});
</script>




</body>
</html>