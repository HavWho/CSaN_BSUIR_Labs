package com.company;

import java.util.Properties;
import java.util.Scanner;

import javax.mail.*;

public class Main {

        public static void main(String[] args) {

            Scanner scanner = new Scanner(System.in);

            System.out.print("Send to: ");

            // Recipient's email ID needs to be mentioned.
            final String toEmail = scanner.nextLine();

            // Sender's email ID needs to be mentioned
            System.out.print("Send from: ");
            final String fromEmail = scanner.nextLine(); //requires valid gmail id
            System.out.print("Password: ");
            final String password = scanner.nextLine();

            System.out.println("SSLEmail Start");
            Properties props = new Properties();
            props.put("mail.smtp.host", "smtp.gmail.com"); //SMTP Host
            props.put("mail.smtp.socketFactory.port", "465"); //SSL Port
            props.put("mail.smtp.socketFactory.class",
                    "javax.net.ssl.SSLSocketFactory"); //SSL Factory Class
            props.put("mail.smtp.auth", "true"); //Enabling SMTP Authentication
            props.put("mail.smtp.port", "465"); //SMTP Port

            Authenticator auth = new Authenticator() {
                //override the getPasswordAuthentication method
                protected PasswordAuthentication getPasswordAuthentication() {
                    return new PasswordAuthentication(fromEmail, password);
                }
            };

            Session session = Session.getDefaultInstance(props, auth);
            System.out.println("Session created");

            System.out.print("Subject of EMail: ");
            String subject = scanner.nextLine();
            System.out.println("Mail text: ");
            String body = scanner.nextLine();

            EmailUtil.sendEmail(session, toEmail, subject, body);

        }

    }
