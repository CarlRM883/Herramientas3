CREATE DATABASE medicamentos;
GO
USE medicamentos;
GO


CREATE TABLE cliente (
    id_cliente VARCHAR(20) PRIMARY KEY,  -- La cédula como clave primaria
    nombre VARCHAR(30) NOT NULL,
    correo VARCHAR(50) UNIQUE NOT NULL,
    telefono VARCHAR(20) NOT NULL
);


CREATE TABLE producto (
    id_producto INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(30) NOT NULL,
    precio DECIMAL(10,2) NOT NULL CHECK (precio >= 0),
    stock INT NOT NULL CHECK (stock >= 0)
);


CREATE TABLE factura (
    id_factura INT IDENTITY(1,1) PRIMARY KEY,
    id_cliente VARCHAR(20) NOT NULL,  -- Referencia a la cédula en cliente
    fecha DATE NOT NULL DEFAULT GETDATE(),
    total DECIMAL(10,2) NOT NULL CHECK (total >= 0),
    CONSTRAINT fk_factura_cliente FOREIGN KEY (id_cliente) 
    REFERENCES cliente(id_cliente) ON DELETE CASCADE
);


CREATE TABLE detallefactura (
    id_factura INT NOT NULL,
    id_producto INT NOT NULL,
    cantidad INT NOT NULL CHECK (cantidad > 0),
    subtotal DECIMAL(10,2) NOT NULL CHECK (subtotal >= 0),
    PRIMARY KEY (id_factura, id_producto),
    CONSTRAINT fk_detalle_factura FOREIGN KEY (id_factura) 
    REFERENCES factura(id_factura) ON DELETE CASCADE,
    CONSTRAINT fk_detalle_producto FOREIGN KEY (id_producto) 
    REFERENCES producto(id_producto)
);


INSERT INTO cliente (id_cliente, nombre, correo, telefono) VALUES
('1001234567', 'Camilo López', 'camilo.lopez@example.com', '3014567890'),
('1007654321', 'Andrea Ramírez', 'andrea.ramirez@example.com', '3156789012'),
('1012345678', 'Juan Pérez', 'juan.perez@example.com', '3207890123'),
('1023456789', 'Diana Torres', 'diana.torres@example.com', '3108901234'),
('1034567890', 'Carlos Mendoza', 'carlos.mendoza@example.com', '3049012345');


INSERT INTO producto (nombre, precio, stock) VALUES
('Acetaminofén 500mg', 5000, 100),
('Ibuprofeno 400mg', 8000, 80),
('Amoxicilina 500mg', 12000, 50),
('Loratadina 10mg', 10000, 60),
('Omeprazol 20mg', 15000, 40);


INSERT INTO factura (id_cliente, total) VALUES
('1001234567', 18000),
('1007654321', 26000),
('1012345678', 15000),
('1023456789', 30000),
('1034567890', 22000);


INSERT INTO detallefactura (id_factura, id_producto, cantidad, subtotal) VALUES
(1, 1, 2, 10000),
(1, 3, 1, 12000),
(2, 2, 2, 16000),
(2, 4, 1, 10000),
(3, 5, 1, 15000),
(4, 1, 3, 15000),
(4, 2, 2, 16000),
(5, 3, 1, 12000),
(5, 4, 1, 10000),
(5, 5, 1, 15000);


SELECT * FROM cliente;
SELECT * FROM producto;
SELECT * FROM factura;
SELECT * FROM detallefactura;

SELECT 
    *
FROM cliente
LEFT JOIN factura ON cliente.id_cliente = factura.id_cliente
LEFT JOIN detallefactura ON factura.id_factura = detallefactura.id_factura
ORDER BY cliente.id_cliente, detallefactura.id_factura;

