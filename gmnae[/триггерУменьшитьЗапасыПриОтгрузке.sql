--������� ��� ��������������� ���������� ���������� ������������� �� ������ ��� --
CREATE TRIGGER trg��������������������������
ON ��������
AFTER INSERT
AS
BEGIN
    UPDATE �������������
    SET ������������� = ������������� - (SELECT ����� FROM inserted)
    WHERE ID�������������� = (SELECT ID�������������� FROM inserted);
END;
GO