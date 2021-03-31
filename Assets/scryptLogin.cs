using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Data;
using System.Text;
using Mono.Data.Sqlite;
using System.Security.Cryptography;
using System.Data.SqlClient;

public class scryptLogin : MonoBehaviour {

    public Text password;
    public Text login;
    public Text label;
    private string Pass;

    private string Hash(string input)
    {
        using (SHA1Managed sha1 = new SHA1Managed())
        {
            var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sb = new StringBuilder(hash.Length * 2);
            foreach (byte b in hash)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }

    public void LogInButtonClick()
    {
        string connectionString = "URI=file:" + Application.dataPath + "/Database/DataBase.bytes";
        using (IDbConnection dbcon = (IDbConnection)new SqliteConnection(connectionString))
        {
            dbcon.Open();
            using (IDbCommand cmd = dbcon.CreateCommand())
            {
                Pass = Hash(password.text);
                cmd.CommandText = "SELECT login, password FROM loginPassword where login like '" + login.text + "' and password like '" + Pass + "'";
                using (IDataReader rez = cmd.ExecuteReader())
                {
                    if (rez.Read())
                    {
                        label.text = "Добро пожаловать " + login.text;
                        Application.LoadLevel("Menu");
                    }
                    else
                    {
                        label.text = "Неверный логин или пароль.";
                        login.text = "";
                        password.text = "";
                    }
                }
            }
            dbcon.Close();
        }
    }

    public void SignUpButtonClick()
    {
        string connectionString = "URI=file:" + Application.dataPath + "/Database/DataBase.bytes";
        using (IDbConnection dbcon = (IDbConnection)new SqliteConnection(connectionString))
        {
            dbcon.Open();
            using (IDbCommand cmd = dbcon.CreateCommand())
            {
                if (login.text != "" && password.text != "")
                {
                    Pass = Hash(password.text);
                    cmd.CommandText = "insert into loginPassword(login, password) values('" + login.text + "','" + Pass + "')";
                    cmd.ExecuteNonQuery();
                    label.text = "Регистрация прошла успешно. Для авторизации введите данные и нажмите 'Авторизация'.";
                }
            }
            dbcon.Close();
        }
    }
}
