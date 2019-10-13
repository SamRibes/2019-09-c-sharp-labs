package com.company;

import com.ExpertSystem.ExpertSystem;
import com.ExpertSystem.Rule;
import java.io.*;
import java.util.ArrayList;

public class Main {

    public static String filename = "SerialisedObjects.ser";

    public static void main(String[] args) throws IOException {

        File file = new File(filename);

        file.createNewFile();

        ArrayList<Rule> knowledgebase = ExpertSystem.BuildKnowledgeBases();

        SerialiseObject(knowledgebase);

        PrintObject(knowledgebase);

        PrintObject(DeserialiseObject());
    }

    private static void SerialiseObject(ArrayList<Rule> knowledgebase)
    {
        try
        {
            FileOutputStream file = new FileOutputStream(filename);
            ObjectOutputStream out = new ObjectOutputStream(file);

            out.writeObject(knowledgebase);

            out.close();
            file.close();


            System.out.println("Object has been serialized");
        }
        catch (FileNotFoundException e)
        {
            e.printStackTrace();
        }
        catch (IOException e)
        {
            e.printStackTrace();
        }
    }

    private static ArrayList<Rule> DeserialiseObject()
    {
        ArrayList<Rule> readKnowledgebase = null;
        try
        {
            FileInputStream file = new FileInputStream("SerialisedObjects.ser");
            ObjectInputStream in = new ObjectInputStream(file);
            readKnowledgebase = (ArrayList<Rule>) in.readObject();
        }
        catch (FileNotFoundException e)
        {
            e.printStackTrace();
        }
        catch (IOException e)
        {
            e.printStackTrace();
        }
        catch (ClassNotFoundException e)
        {
            e.printStackTrace();
        }
        return readKnowledgebase;
    }

    private static void PrintObject(ArrayList<Rule> readObject)
    {
        System.out.println(readObject);
    }
}
