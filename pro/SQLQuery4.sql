SELECT 
    fk.name AS ForeignKey,
    tp.name AS ParentTable,
    tr.name AS ReferencedTable,
    fk.delete_referential_action_desc AS DeleteAction
FROM 
    sys.foreign_keys AS fk
INNER JOIN 
    sys.tables AS tp ON fk.parent_object_id = tp.object_id
INNER JOIN 
    sys.tables AS tr ON fk.referenced_object_id = tr.object_id
WHERE 
    tp.name = 'Account' AND fk.name = 'FK_Customer';
