<?php

use CodeIgniter\Router\RouteCollection;

/**
 * @var RouteCollection $routes
 */

$routes->get('/', 'crud::index');
$routes->get('/eliminar/(:any)', 'crud::eliminar/$1');
