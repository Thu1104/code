/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package project_dbms;

import com.mysql.jdbc.Connection;
import java.sql.DriverManager;

/**
 *
 * @author ASUS
 */
public class MySQLConnect {
    public Connection ConnectMySQL(){
    Connection connect = null;
    try{
        Class.forName("com.mysql.jdbc.Driver").newInstance();
        connect = (Connection) DriverManager.getConnection("jdbc:mysql://localhost/qlks?" + "user=root");
    } catch (Exception ex){
            ex.printStackTrace();
        }
    return connect;
    }
}
