IF NOT EXISTS (SELECT 1 FROM dbo.Pet)
BEGIN
    INSERT INTO dbo.Pet (Id, Name) VALUES
    (NEWID(), 'Fluffy'),
    (NEWID(), 'Rex'),
    (NEWID(), 'Tweety'),
    (NEWID(), 'Nemo'),
    (NEWID(), 'Hammy'),
    (NEWID(), 'Whiskers'),
    (NEWID(), 'Buddy'),
    (NEWID(), 'Polly'),
    (NEWID(), 'Goldie'),
    (NEWID(), 'Speedy');
END