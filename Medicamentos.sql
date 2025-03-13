-- Crear la base de datos
CREATE DATABASE medicamentos;
GO
USE medicamentos;
GO

-- Creación de la tabla cliente
CREATE TABLE cliente (
    id_cliente VARCHAR(20) PRIMARY KEY,  -- La cédula como clave primaria
    nombre VARCHAR(30) NOT NULL,
    correo VARCHAR(50) UNIQUE NOT NULL,
    telefono VARCHAR(20) NOT NULL
);

-- Creación de la tabla producto
CREATE TABLE producto (
    id_producto INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(30) NOT NULL,
    precio DECIMAL(10,2) NOT NULL CHECK (precio >= 0),
    stock INT NOT NULL CHECK (stock >= 0)
);

-- Creación de la tabla factura
CREATE TABLE factura (
    id_factura INT IDENTITY(1,1) PRIMARY KEY,
    id_cliente VARCHAR(20) NOT NULL,  -- Referencia a la cédula en cliente
    fecha DATE NOT NULL DEFAULT GETDATE(),
    total DECIMAL(10,2) NOT NULL CHECK (total >= 0),
    CONSTRAINT fk_factura_cliente FOREIGN KEY (id_cliente) 
    REFERENCES cliente(id_cliente) ON DELETE CASCADE
);

-- Creación de la tabla detallefactura
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

