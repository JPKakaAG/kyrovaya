--Триггер для проверки валидности цены при изменении комплектующего
CREATE TRIGGER ПроверкаВалидностиЦены
ON Комплектующие
FOR UPDATE
AS
BEGIN
    IF EXISTS (SELECT * FROM inserted WHERE Цена < 0)
    BEGIN
        RAISERROR ('Цена не может быть отрицательной.', 16, 1);
        ROLLBACK TRANSACTION;
    END;
END;
GO