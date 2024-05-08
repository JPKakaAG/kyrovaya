--Процедура для добавления нового складского отделения
CREATE PROCEDURE ДобавитьСклад
    @Местоположение VARCHAR(100)
AS
BEGIN
    INSERT INTO Склад (Location)
    VALUES (@Местоположение);
END;