/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [id]
      ,[nombre]
  FROM [prueba].[dbo].[contacto]

  SELECT top 10 *
  FROM contacto  where id=4


  ----- actulizar 
  update contacto
  set nombre ='MOD'
  where id=1

  --- insertar
  insert  contacto
  values  (  5, 'vane' )


   insert  contacto
  values  (  'vane 2' )

  --- ES PARA  INSERT  UN ID ESPECIFICO , AQUI  INSERTA
  SET IDENTITY_INSERT contacto ON
  insert  contacto ( ID,  NOMBRE )
  values  (  5, 'FGA' )
  SET identity_insert contacto OFF
  

  delete contacto
  where  id=5