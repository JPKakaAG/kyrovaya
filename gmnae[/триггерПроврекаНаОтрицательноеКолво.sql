--������� ��� �������������� �������������� ���������� �� ������
CREATE TRIGGER ����������������������������
ON �������������
AFTER UPDATE
AS
BEGIN
    IF EXISTS (SELECT * FROM inserted WHERE ������������� < 0)
    BEGIN
        ROLLBACK TRANSACTION;
        RAISERROR('���������� �� ������ �� ����� ���� �������������.', 16, 1);
    END;
END;