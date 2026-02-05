SELECT product_id, product_name, [description]
FROM products
WHERE    [description] COLLATE Latin1_General_CS_AS like '% SN[0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9] %'
      OR [description] COLLATE Latin1_General_CS_AS like   'SN[0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9] %'
      OR [description] COLLATE Latin1_General_CS_AS like '% SN[0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]'
      OR [description] COLLATE Latin1_General_CS_AS like   'SN[0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]'
ORDER BY product_id
