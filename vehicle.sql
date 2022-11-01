CREATE TABLE TruckSlot (
	Id 				SERIAL PRIMARY KEY NOT NULL,
	TruckId     	VARCHAR(24) NOT NULL,
	StartDate    	Date,
	EndDate       	Date
);



INSERT INTO TruckSlot (TruckId, StartDate, EndDate) VALUES ('1', '2022-6-1', '2022-6-3');
INSERT INTO TruckSlot (TruckId, StartDate, EndDate) VALUES ('2', '2022-7-1', '2022-7-3');
INSERT INTO TruckSlot (TruckId, StartDate, EndDate) VALUES ('3', '2022-8-1', '2022-8-3');



SELECT * FROM public.TruckSlot ORDER BY id ASC 
