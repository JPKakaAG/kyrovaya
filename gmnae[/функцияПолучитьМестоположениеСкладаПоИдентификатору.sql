--������� ��� ��������� �������������� ������ �� ��� ID
CREATE FUNCTION dbo.fn_�������������������������������������������� (@ID������ INT)
RETURNS VARCHAR(100)
AS
BEGIN
    DECLARE @�������������� VARCHAR(100);

    SELECT @�������������� = Location
    FROM �����
    WHERE ID������ = @ID������;

    RETURN @��������������;
END;