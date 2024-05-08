--Триггер для предотвращения отрицательного количества на складе
CREATE TRIGGER ПроврекаНаОтрицательноеКолво
ON Комплектующие
AFTER UPDATE
AS
BEGIN
    IF EXISTS (SELECT * FROM inserted WHERE КолвоНаСкладе < 0)
    BEGIN
        ROLLBACK TRANSACTION;
        RAISERROR('Количество на складе не может быть отрицательным.', 16, 1);
    END;
END;