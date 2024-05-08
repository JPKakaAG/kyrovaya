--Триггер для автоматического уменьшения количества комплектующих на складе при --
CREATE TRIGGER trgУменьшитьЗапасыПриОтгрузке
ON Отгрузки
AFTER INSERT
AS
BEGIN
    UPDATE Комплектующие
    SET КолвоНаСкладе = КолвоНаСкладе - (SELECT Колво FROM inserted)
    WHERE IDКомплектующего = (SELECT IDКомплектующего FROM inserted);
END;
GO