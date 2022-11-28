--------------------------------------------
-- SPs for Commands
--------------------------------------------
DROP PROCEDURE IF EXISTS sp_insert_{entity_domain}(
	INOUT _id BIGINT,
	{insert_parameters}
	INOUT _created_at DATE,
	INOUT _updated_at DATE
	
);

CREATE OR REPLACE PROCEDURE sp_insert_{entity_domain}(
	INOUT _id BIGINT,
	{insert_parameters}
	INOUT _created_at DATE,
	INOUT _updated_at DATE
)
LANGUAGE PLPGSQL AS $plpgsql$
BEGIN

	INSERT INTO public.{entity_domain} (
		{insert_fields}
		created_at,
		updated_at
	) 
	VALUES
	(
		{insert_values}
		now(),
		now()
	) 
	
	RETURNING id, created_at, updated_at INTO _id, _created_at, _updated_at;
	
	
END
$plpgsql$;

DROP PROCEDURE IF EXISTS sp_update_{entity_domain}(
	_id BIGINT,
	{update_parameters}
	INOUT _created_at DATE,
	INOUT _updated_at DATE
);

CREATE OR REPLACE PROCEDURE sp_update_{entity_domain}
(
	_id BIGINT,
	{update_parameters}
	INOUT _created_at DATE,
	INOUT _updated_at DATE
	)
LANGUAGE plpgsql AS $plpgsql$
BEGIN
	UPDATE public.{entity_domain} SET 
		{update_values}
		updated_at = now()
	where id = _id
	
	RETURNING created_at, updated_at INTO _created_at, _updated_at;
	
END
$plpgsql$;


DROP PROCEDURE IF EXISTS sp_delete_{entity_domain}(INOUT _id BIGINT);
CREATE OR REPLACE PROCEDURE sp_delete_{entity_domain}(INOUT _id BIGINT)
LANGUAGE plpgsql AS $plpgsql$
BEGIN
	DELETE FROM public.{entity_domain} WHERE id = _id;
END
$plpgsql$;

