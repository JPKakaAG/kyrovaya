--������� ��� �������� ���������� ���� ��� ��������� ��������������
CREATE TRIGGER ����������������������
ON �������������
FOR UPDATE
AS
BEGIN
    IF EXISTS (SELECT * FROM inserted WHERE ���� < 0)
    BEGIN
        RAISERROR ('���� �� ����� ���� �������������.', 16, 1);
        ROLLBACK TRANSACTION;
    END;
END;
GO