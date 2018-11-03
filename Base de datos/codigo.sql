
create sequence id_factura
	start with 100000
	increment by 1
	maxvalue 4294967296
	minvalue 1;

create table public.factura(
	id integer default nextval('id_factura'),
	name text,
	status text,
	fecha timestamp default current_timestamp,
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

create or replace function addFactura( _name text, _status text, _data text )
returns void as
$$
begin
	insert into public.factura (name, status, data) values (_name, _status, _data);
end
$$ language plpgsql;

create or replace function updateFactura( _id integer, _name text, _status text, _data text )
returns void as
$$
begin
	update public.factura set name = _name, status = _status, data = _data where id = _id;
end
$$ language plpgsql;

 
-- select * from addFactura('Correcto', '{"Name": "prueba"}');
-- select * from getAllFactura();
-- select * from updateFactura(1, '{"Name": "prueba2"}');