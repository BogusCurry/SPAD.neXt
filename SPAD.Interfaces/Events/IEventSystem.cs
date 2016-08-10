﻿using SPAD.neXt.Interfaces;
using SPAD.neXt.Interfaces.Base;
using SPAD.neXt.Interfaces.Configuration;
using SPAD.neXt.Interfaces.Events;
using SPAD.neXt.Interfaces.Profile;
using SPAD.neXt.Interfaces.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace SPAD.neXt.Interfaces.Events
{

    public interface IEventSystemHandler
    {
        IEventDefinition CreateEvent(string boundTo,string trigger);
        IEventAction CreateAction(SPADEventActions action);
        IEventAction CreateAction(string action);
        IEventCondition CreateCondition();
        IEventCondition CreateCondition(IDataDefinition dataSource, SPADEventValueComparator comparator, string targetValue);
        IEventDefinitions CreateEventDefinitions(string boundTo);

        Type[] GetExtraSerializationTypes();
        IValueProvider GetValueProvider(string provider);
        IEnumerable<string> GetValueProviders(bool onlyActive = true);
        IDataDefinition GetDataDefinition(string id, SPADDefinitionTypes definitionType = SPADDefinitionTypes.OFFSET);
        IDataDefinitions GetDataDefinitions(SPADDefinitionTypes definitionType = SPADDefinitionTypes.OFFSET);
        IDataDefinition CreateNewLocal(string name, string displaynormalizer);
        IEnumerable<string> GetKnownNormalizers(string startWith = null);
        IEnumerable<IDynamicNormalizer> GetDynamicNormalizers();
        IDataDefinition BrowseDataDefiniton(string curOffset, string titleName, string rootName, bool bWriteOperation, object parentWindow = null);
        IReadOnlyList<IDataDefinition> BrowseDataDefinitonMulti(string curOffset, string titleName, string rootName, bool bWriteOperation, object parentWindow = null);
        void StartRecording();
        IEnumerable<IMonitorableValue> StopRecording();
    }

    public sealed class EventSystem 
    {
        private static IEventSystemHandler EventSystemHandler { get; set; }

        public static void SetHandler(IEventSystemHandler handler)
        {
            EventSystemHandler = handler;
        }

        public static IEventCondition CreateCondition(IDataDefinition dataSource, SPADEventValueComparator comparator, string targetValue)
        {
            return EventSystemHandler.CreateCondition(dataSource, comparator, targetValue);
        }
        public static IDataDefinition BrowseDataDefiniton(string curOffset, string titleName, string rootName, bool bWriteOperation, object parentWindow = null)
        {
            return EventSystemHandler.BrowseDataDefiniton(curOffset, titleName, rootName, bWriteOperation, parentWindow);
        }
        public static IReadOnlyList<IDataDefinition> BrowseDataDefinitonMulti(string curOffset, string titleName, string rootName, bool bWriteOperation, object parentWindow = null)
        {
            return EventSystemHandler.BrowseDataDefinitonMulti(curOffset, titleName, rootName, bWriteOperation, parentWindow);
        }
        public static IEventAction CreateAction(string action)
        {
            return EventSystemHandler.CreateAction(action);
        }
        public static IEventAction CreateAction(SPADEventActions action)
        {
            return EventSystemHandler.CreateAction(action);
        }
        public static T CreateAction<T>(SPADEventActions action)
        {
            return (T)EventSystemHandler.CreateAction(action);
        }
        public static IEventDefinition CreateEvent(string boundTo, string trigger)
        {
            return EventSystemHandler.CreateEvent(boundTo, trigger);
        }

        public static IEventCondition CreateCondition()
        {
            return EventSystemHandler.CreateCondition();
        }

        public static IDataDefinition CreateNewLocal(string name, string displaynormalizer)
        {
            return EventSystemHandler.CreateNewLocal(name, displaynormalizer);
        }

        public static IDataDefinition GetDataDefinition(string id, SPADDefinitionTypes definitionType = SPADDefinitionTypes.OFFSET)
        {
            return EventSystemHandler.GetDataDefinition(id, definitionType);
        }

        public static IEnumerable<IDynamicNormalizer> GetDynamicNormalizers()
        {
            return EventSystemHandler.GetDynamicNormalizers();
        }

        public static IDataDefinitions GetDataDefinitions(SPADDefinitionTypes definitionType = SPADDefinitionTypes.OFFSET)
        {
            return EventSystemHandler.GetDataDefinitions(definitionType);
        }

        public static Type[] GetExtraSerializationTypes()
        {
            return EventSystemHandler.GetExtraSerializationTypes();
        }

        public static IEnumerable<string> GetKnownNormalizers(string startWith = null)
        {
            return EventSystemHandler.GetKnownNormalizers(startWith);
        }

        public static IEventDefinitions CreateEventDefinitions(string boundTo)
        {
            return EventSystemHandler.CreateEventDefinitions(boundTo);
        }

        public static IValueProvider GetValueProvider(string provider)
        {
            return EventSystemHandler.GetValueProvider(provider);
        }

        public static IEnumerable<string> GetValueProviders(bool onlyActive = true)
        {
            return EventSystemHandler.GetValueProviders(onlyActive);
        }

        public static void StartRecording()
        {
            EventSystemHandler.StartRecording();
        }

        public static IEnumerable<IMonitorableValue> StopRecording()
        {
            return EventSystemHandler.StopRecording();
        }
    }
}