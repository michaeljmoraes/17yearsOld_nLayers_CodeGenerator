--------------------------------------------
-- FNs for Queries
--------------------------------------------
DROP FUNCTION IF EXISTS fn_get_{entity_domain}(_id BIGINT);
CREATE OR REPLACE FUNCTION fn_get_{entity_domain}(_id BIGINT)
RETURNS SETOF public.{entity_domain} LANGUAGE plpgsql AS $plpgsql$
BEGIN
	RETURN QUERY (SELECT * FROM public.{entity_domain} where id = _id);
END
$plpgsql$;

DROP FUNCTION IF EXISTS fn_get_all_{entity_domain}();
CREATE OR REPLACE FUNCTION fn_get_all_{entity_domain}()
  RETURNS SETOF public.{entity_domain} LANGUAGE plpgsql AS $plpgsql$
BEGIN
	RETURN QUERY (SELECT * FROM public.{entity_domain});
END
$plpgsql$;
