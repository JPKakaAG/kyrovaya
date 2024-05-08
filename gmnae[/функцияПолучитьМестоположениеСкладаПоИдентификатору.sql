--Функция для получения местоположения склада по его ID
CREATE FUNCTION dbo.fn_ПолучитьМестоположениеСкладаПоИдентификатору (@IDСклада INT)
RETURNS VARCHAR(100)
AS
BEGIN
    DECLARE @Местоположение VARCHAR(100);

    SELECT @Местоположение = Location
    FROM Склад
    WHERE IDСклада = @IDСклада;

    RETURN @Местоположение;
END;