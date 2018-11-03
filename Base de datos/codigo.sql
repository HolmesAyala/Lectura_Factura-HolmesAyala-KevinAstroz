create table public.factura(
	id serial,
	data text,
	primary key(id)
);

create or replace function getFactura( _id integer )
returns setof public.factura as
$$
begin
	return query select * from public.factura where id = _id;
end
$$ language plpgsql;

create or replace function getAllFactura()
returns setof public.factura as
$$
begin
	return query select * from public.factura;
end
$$ language plpgsql;

create or replace function addFactura( _data text )
returns void as
$$
begin
	insert into public.factura (data) values (_data);
end
$$ language plpgsql;

create or replace function updateFactura( _id integer, _data text )
returns void as
$$
begin
	update public.factura set data = _data where id = _id;
end
$$ language plpgsql;

-- select * from addFactura('{"Name": "prueba"}');
-- select * from getAllFactura();
-- select * from updateFactura(1, '{"Name": "prueba2"}');



