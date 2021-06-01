DELIMITER $$
CREATE DEFINER=`root`@`%` FUNCTION `check_palindrome`(str varchar(100)) RETURNS tinyint(1)
    READS SQL DATA
    DETERMINISTIC
BEGIN
		DECLARE reverstr varchar(100);
        DECLARE result boolean;
        SET reverstr = REVERSE(str);
       SELECT IF(STRCMP(reverstr,str)=0, true, false) INTO result;
RETURN result;
END$$
DELIMITER ;
