-- Crear la tabla CONTACTO
CREATE TABLE CONTACTO (
    IdContacto INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(50),
    Telefono VARCHAR(50),
    Correo VARCHAR(50)
);

-- Crear el procedimiento almacenado para listar todos los contactos
DELIMITER //
CREATE PROCEDURE sp_Listar()
BEGIN
    SELECT * FROM CONTACTO;
END //
DELIMITER ;

-- Crear el procedimiento almacenado para obtener un contacto por IdContacto
DELIMITER //
CREATE PROCEDURE sp_Obtener(IN p_IdContacto INT)
BEGIN
    SELECT * FROM CONTACTO WHERE IdContacto = p_IdContacto;
END //
DELIMITER ;

-- Crear el procedimiento almacenado para guardar un nuevo contacto
DELIMITER //
CREATE PROCEDURE sp_Guardar(
    IN Nombre VARCHAR(100),
    IN Telefono VARCHAR(100),
    IN Correo VARCHAR(100)
)
BEGIN
    INSERT INTO CONTACTO (Nombre, Telefono, Correo)
    VALUES (Nombre, Telefono, Correo);
END //
DELIMITER ;

-- Crear el procedimiento almacenado para editar un contacto existente
DELIMITER //
CREATE PROCEDURE sp_Editar(
    IN IdContacto INT,
    IN Nombre VARCHAR(100),
    IN Telefono VARCHAR(100),
    IN Correo VARCHAR(100)
)
BEGIN
    UPDATE CONTACTO 
    SET Nombre = Nombre, Telefono = Telefono, Correo = Correo 
    WHERE IdContacto = IdContacto;
END //
DELIMITER ;

-- Crear el procedimiento almacenado para eliminar un contacto
DELIMITER //
CREATE PROCEDURE sp_Eliminar(IN p_IdContacto INT)
BEGIN
    DELETE FROM CONTACTO WHERE IdContacto = p_IdContacto;
END //
DELIMITER ;


call sp_Eliminar(3);
select * from contacto;